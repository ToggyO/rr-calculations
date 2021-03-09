import type { AxiosResponse } from 'axios';

import superaxios from './superaxios';
import type { CalculationDTO, UsersTableRow } from '../components/UsersTable/interfaces';

export async function getUsers(): Promise<AxiosResponse<API.SuccessResponse<API.List<UsersTableRow>>>> {
  return superaxios.get('/users', {
    params: { page: 1, pageSize: 9999 },
  });
}

export async function saveUsers(users: Omit<UsersTableRow, 'id'>[]): Promise<AxiosResponse<API.SuccessResponse<void>>> {
  return superaxios.post('/users', { users });
}

export async function calculate(): Promise<AxiosResponse<API.SuccessResponse<CalculationDTO>>> {
  return superaxios.get('/users/calculate');
}
