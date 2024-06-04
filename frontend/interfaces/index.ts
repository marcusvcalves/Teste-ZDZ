export interface Product{
  id: number,
  name: string,
  price: number,
  description: string
  category: Category,
  pageIndex: number,
  totalPages: number,
  hasPreviousPage: boolean,
  hasNextPage: boolean
}

export interface Category{
  id: number,
  name: string
}

export interface State{
  products: Product[],
  categories: Category[]
}