export interface Product{
  id: number,
  name: string,
  price: number,
  description: string
}

export interface Category{
  id: number,
  name: string
}

export interface State{
  products: Product[],
  categories: Category[]
}