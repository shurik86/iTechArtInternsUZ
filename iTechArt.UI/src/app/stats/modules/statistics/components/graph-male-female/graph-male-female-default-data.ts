import { ChartConfiguration } from 'chart.js';

export const barGraphSexDefaultData: ChartConfiguration<'bar'>['data'] = {
  labels: ['Groceries', 'Pupils', 'Police', 'Students', 'Staffs'],
  datasets: [
    {
      data: [0, 0, 0, 0, 0],
      label: 'males',
    },
    {
      data: [0, 0, 0, 0, 0],
      label: 'females',
    },
  ],
};
