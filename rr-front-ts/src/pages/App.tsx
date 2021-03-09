import React from 'react';
import { renderRoutes } from 'react-router-config';
import type { RouteConfigComponentProps } from 'react-router-config';

import styles from './App.module.sass';

const App: React.FC<RouteConfigComponentProps> = ({ route }) => (
  <div className={styles.wrapper}>{renderRoutes(route?.routes)}</div>
);

export default App;
