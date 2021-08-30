import { IStat } from './stat';

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IStat[];
}

export class Pagination implements IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IStat[] = [];
}
