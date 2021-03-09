import React, { useCallback, useState } from 'react';

import { UsersTableHeader } from './UsersTableHeader';
import { UsersTableBody } from './UsersTableBody';
import { AddOneMore } from './AddOneMore';

import type { IUsersTableProps, UsersTableRow } from './interfaces';

import { Button } from '../Button';

import styles from './index.module.sass';

export const UsersTable: React.FC<IUsersTableProps> = ({
  dataSource, onAdd, onSave, onRemove,
}) => {
  const [isFormShown, toggleShow] = useState(false);
  const handleShow = useCallback(() => toggleShow(true), [toggleShow]);
  const handleAdd = useCallback((data: Omit<UsersTableRow, 'id'>) => {
    onAdd(data);
    toggleShow(false);
  }, [onAdd]);
  const handleClose = useCallback(() => toggleShow(false), []);

  if (!dataSource) {
    dataSource = [];
  }

  return (
    <div className={styles.wrapper}>
      <table className={styles.table}>
        <UsersTableHeader />
        <UsersTableBody
          dataSource={dataSource}
          isFormShown={isFormShown}
          onAdd={handleAdd}
          onClose={handleClose}
          onRemove={onRemove}
        />
      </table>
      <AddOneMore disabled={isFormShown} onShow={handleShow} />
      <Button
        text="SAVE"
        onClick={onSave}
      />
    </div>
  );
};
