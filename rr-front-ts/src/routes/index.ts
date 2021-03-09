import type { RouteConfig } from 'react-router-config';

import App from '../pages/App';
import Calculations from '../pages/Calculations';

export default [
  {
    component: App,
    routes: [
      {
        path: '/',
        exact: true,
        component: Calculations,
      },
    ],
  },
] as RouteConfig[];
