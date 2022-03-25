export class PageList<model> {
    indexFrom: number;
    pageIndex: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    items: model[];
    hasPreviousPage: boolean;
    hasNextPage: boolean;
}