import React from 'react';

import { CrossAdd } from '../../SvgIcons';
import type { IAddOneMoreProps } from './interfaces';

import styles from './index.module.sass';

export const AddOneMore: React.FC<IAddOneMoreProps> = ({ disabled, onShow }) => (
  <div className={styles.container}>
    <button
      className={styles.button}
      type="button"
      onClick={onShow}
      disabled={disabled}
    >
      <CrossAdd className={styles.icon} />
      <div className={styles.text}>Add one more</div>
    </button>
  </div>
);
