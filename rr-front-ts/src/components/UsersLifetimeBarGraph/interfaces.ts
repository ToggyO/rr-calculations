export type BarChartData<T> = {
  text: string;
  value: T;
};

export interface IUsersLifetimeBarGraph<T> {
  chartData: BarChartData<T>[];
}
