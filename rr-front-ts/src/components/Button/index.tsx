import React from 'react';

import type { IButtonProps } from './interfaces';

import styles from './index.module.sass';

export const Button: React.FC<IButtonProps> = ({
  type = 'button',
  text = '',
  onClick,
  disabled,
}) => (
  <div className={styles.container}>
    <button
      className={styles.button}
      // eslint-disable-next-line react/button-has-type
      type={type}
      onClick={onClick}
      disabled={disabled}
    >
      {text}
    </button>
  </div>
);
