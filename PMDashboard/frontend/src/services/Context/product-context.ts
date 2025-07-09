import { createContext } from "react";
import type { IProductDTO } from "../../types/IProductDTO";
import type { IProduct } from "../../types/IProduct";

export const ProductContext = createContext({
    products: [] as IProduct[],
    addItemToProducts: (product: IProductDTO) => {},
    removeItemFromProducts: () => {},
    selectedProduct: null as IProduct | null,
    setSelectedProduct: (product: IProduct) => {}
})
