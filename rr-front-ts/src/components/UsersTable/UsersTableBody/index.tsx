import React from 'react';

import { CrossClose } from '../../SvgIcons';
import { AddUserForm } from './_components/AddUserForm';
import type { IUsersTaleBodyProps } from './interfaces';
import type { UsersTableRow } from '../interfaces';

import styles from './index.module.sass';

export const UsersTableBody: React.FC<IUsersTaleBodyProps> = ({
  dataSource, isFormShown, onAdd, onClose, onRemove,
}) => {
  const renderRow = (item: UsersTableRow, index: number) => (
    <tr key={index} className={styles.row}>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <div className={styles.cell_item}>
            {item.id}
          </div>
        </div>
      </td>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <div className={styles.cell_item}>
            {item.registrationDate}
          </div>
        </div>
      </td>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <div className={styles.cell_item}>
            {item.lastActivityDate}
          </div>
        </div>
      </td>
      <td>
        <button
          className={styles.actions__cross_close}
          onClick={() => onRemove(item.id as number)}
          type="button"
        >
          <CrossClose />
        </button>
      </td>
    </tr>
  );
  return (
    <tbody>
      {dataSource.map((item, index) => renderRow(item, index))}
      {isFormShown && <AddUserForm onAdd={onAdd} onClose={onClose} />}
    </tbody>
  );
};
