import React from 'react';

import styles from './index.module.sass';

export const UsersTableHeader: React.FC = () => (
  <thead className={styles.header}>
    <tr className={styles.header_element}>
      <th>User Id</th>
      <th>Registration Date</th>
      <th>Last Activity Date</th>
    </tr>
  </thead>
);
