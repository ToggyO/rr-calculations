import React from 'react';

import { Spinner } from '../SvgIcons';
import type { ILoaderProps } from './interfaces';

import styles from './index.module.sass';

export const Loader: React.FC<ILoaderProps> = ({ children, loading }) => (
  <div className={styles.container}>
    {loading && (
      <div className={styles.spinner}>
        <>
          <div className={styles.overlay} />
          <Spinner />
        </>
      </div>
    )}
    <div>{children}</div>
  </div>
);
