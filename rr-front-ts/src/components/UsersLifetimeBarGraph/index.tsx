import React from 'react';
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-ignore
import BarChart from 'react-bar-chart';

import type { BarChartData, IUsersLifetimeBarGraph } from './interfaces';

const margin = {
  top: 20, right: 20, bottom: 30, left: 40,
};

export const UsersLifetimeBarGraph: React.FC<IUsersLifetimeBarGraph<number>> = ({ chartData }) => {
  const handleBarClick = (element: BarChartData<number>, id: number) => {
    console.log(`The bin ${element.text} with id ${id} was clicked`);
  };
  return (
    <div>
      <BarChart
        ylabel="Alive users"
        xlabel="Date"
        width={1500}
        height={300}
        margin={margin}
        data={chartData}
        onBarClick={handleBarClick}
      />
    </div>
  );
};
