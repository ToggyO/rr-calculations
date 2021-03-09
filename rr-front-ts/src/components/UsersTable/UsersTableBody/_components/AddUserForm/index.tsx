import React, { useCallback, useState } from 'react';

import { CheckMark, CrossClose } from '../../../../SvgIcons';
import type { IAddUserFormProps } from './interfaces';

import styles from '../../index.module.sass';

export const AddUserForm: React.FC<IAddUserFormProps> = ({ onAdd, onClose }) => {
  const [regDate, setRegDate] = useState('');
  const [lastActivity, setLastActivity] = useState('');
  const handleAdd = useCallback(() => onAdd({
    registrationDate: regDate,
    lastActivityDate: lastActivity,
  }), [onAdd, regDate, lastActivity]);
  return (
    <tr className={`${styles.row} ${styles.new_row}`}>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <div className={styles.cell_item} style={{ height: 18 }} />
        </div>
      </td>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <input
            type="text"
            className={styles.cell_item}
            value={regDate}
            onChange={(e) => setRegDate(e.target.value)}
          />
        </div>
      </td>
      <td className={styles.cell}>
        <div className={styles.cell_container}>
          <input
            type="text"
            className={styles.cell_item}
            value={lastActivity}
            onChange={(e) => setLastActivity(e.target.value)}
          />
        </div>
      </td>
      <td className={`${styles.actions} ${styles.cell}`}>
        <button
          className={styles.actions__check_mark}
          onClick={handleAdd}
          type="button"
        >
          <CheckMark />
        </button>
        <button
          className={styles.actions__cross_close}
          onClick={onClose}
          type="button"
        >
          <CrossClose />
        </button>
      </td>
    </tr>
  );
};
