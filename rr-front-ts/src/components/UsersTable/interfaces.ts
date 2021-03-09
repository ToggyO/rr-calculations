export type UsersTableRow = {
  id: number | string;
  registrationDate: string;
  lastActivityDate: string;
};

export interface IUsersTableProps {
  dataSource: UsersTableRow[];
  onAdd: (...args: any[]) => any;
  onSave: (...args: any[]) => any;
  onRemove: (id: number) => void;
}

export type UsersLifetime = {
  date: string;
  aliveUsersCount: number;
};

export type CalculationDTO = {
  rollingRetention: string;
  usersLifetime: UsersLifetime[];
};
