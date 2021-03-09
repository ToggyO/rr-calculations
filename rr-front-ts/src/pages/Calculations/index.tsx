import React, { useState, useCallback, useEffect } from 'react';

import { getUsers, saveUsers, calculate } from '../../services/api';
import { Loader } from '../../components/Loader';
import { UsersTable } from '../../components/UsersTable';
import { Button } from '../../components/Button';
import { UsersLifetimeBarGraph } from '../../components/UsersLifetimeBarGraph';
import type { BarChartData } from '../../components/UsersLifetimeBarGraph/interfaces';
import type { UsersTableRow } from '../../components/UsersTable/interfaces';

import styles from './index.module.sass';

const getUsersRequest = async () => getUsers();

const saveUsersReuqest = async (data: Omit<UsersTableRow, 'id'>[]) => saveUsers(data);

const calculateRequest = async () => calculate();

const Calculations: React.FC = () => {
  const [loading, toggleLoading] = useState(true);
  const [users, setUsers] = useState<UsersTableRow[]>([]);
  const [rr, setRR] = useState('');
  const [usersLifetime, setUsersLifetime] = useState<BarChartData<number>[]>([]);

  const memoizedUsersRequest = useCallback(async () => getUsersRequest()
    .then((res) => {
      setUsers(res.data.resultData.items);
      toggleLoading(false);
    }).catch((err) => {
      console.log(err);
      toggleLoading(false);
    }),
  []);

  useEffect(() => {
    toggleLoading(true);
    memoizedUsersRequest().then((res) => console.log(res)).catch((err) => console.log(err));
  }, [memoizedUsersRequest]);

  const onAdd = useCallback((newUser: Omit<UsersTableRow, 'id'>) => {
    setUsers([
      ...users, { ...newUser, id: users.length + 1 },
    ]);
  }, [setUsers, users]);

  const onSave = useCallback(() => {
    toggleLoading(true);
    const savedUsers = users.map((user) => ({
      registrationDate: user.registrationDate,
      lastActivityDate: user.lastActivityDate,
    }));
    saveUsersReuqest(savedUsers)
      .then(() => memoizedUsersRequest())
      .catch((err) => {
        toggleLoading(false);
        console.log(err);
      });
  }, [users, memoizedUsersRequest]);

  const onRemove = useCallback((id: number) => {
    const newUsers = users.filter((user) => user.id !== id);
    setUsers(newUsers);
  }, [users, setUsers]);

  const calculateAction = useCallback(() => {
    toggleLoading(true);
    calculateRequest()
      .then((res) => {
        setRR(res.data.resultData.rollingRetention);
        const chartData = res.data.resultData.usersLifetime.map<BarChartData<number>>((item) => ({
          text: item.date.slice(0, 10),
          value: item.aliveUsersCount,
        }));
        setUsersLifetime(chartData);
        toggleLoading(false);
      })
      .catch((err) => {
        toggleLoading(false);
        console.log(err);
      });
  }, []);
  return (
    <Loader loading={loading}>
      <div className={styles.wrapper}>
        <h2>Calculations</h2>
        <UsersTable
          dataSource={users}
          onAdd={onAdd}
          onSave={onSave}
          onRemove={onRemove}
        />
        <Button
          onClick={calculateAction}
          text="CALCULATE"
        />
        <h1>
          Rolling Retention&nbsp;
          {rr}
        </h1>
        <div className={styles.chart}>
          <UsersLifetimeBarGraph chartData={usersLifetime} />
        </div>
      </div>
    </Loader>
  );
};

export default Calculations;
