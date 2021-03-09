import type { UsersTableRow } from '../interfaces';

export interface IUsersTaleBodyProps {
  dataSource: UsersTableRow[];
  isFormShown: boolean;
  onAdd: (...args: any[]) => any;
  onClose: (...args: any[]) => any;
  onRemove: (id: number) => void;
}
