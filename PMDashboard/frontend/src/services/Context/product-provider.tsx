import { useEffect, useState } from "react"
import type { IProduct } from "../../types/IProduct"
import { ProductContext } from "./product-context"
import type { IProductDTO } from "../../types/IProductDTO"

const baseUrl = "http://localhost:5059/api/Product"

export default function ProductProvider({children}: {children: React.ReactNode}) {
    const [products, setProducts] = useState<IProduct[]>([])
    const [pending, setPending] = useState(true)
    const [selectedProduct, setSelectedProduct] = useState<IProduct | null>(null)

    useEffect(() => {
        async function getAll() {
            try {
                const result = await fetch(`${baseUrl}/GetAll`)
                const data: IProduct[] = await result.json()
                setProducts(data)
                setPending(false)
            } catch (e) {
                console.log(e)
            }
        }
        getAll()
    }, [])

    const addItemToProducts = (product: IProductDTO) => {
        const formData = new FormData();
        formData.append("name", product.name);
        formData.append("category", product.category.toString());
        formData.append("price", product.price.toString());
        formData.append("stockQuantity", product.stockQuantity.toString());

        fetch(`${baseUrl}/Create`, {
            method: "POST",
            body: formData
        })
        .then(res => res.json())
        .then(data => setProducts(products => [...products, data]))
        .catch(err => console.log(err))
    }

    const removeItemFromProducts = () => { 
        if (!selectedProduct) return;
        const formData = new FormData();
        formData.append("id", selectedProduct?.id.toString() ?? "");
        
        fetch(`${baseUrl}/Delete`, {
            method: "POST",
            body: formData
        })
        .then(res => res.json())
        .then(() => setProducts(products => products.filter(p => p.id !== selectedProduct?.id)))
        .catch(err => console.log(err))
    }
    
    const value = {
        products,
        addItemToProducts,
        removeItemFromProducts,
        selectedProduct,
        setSelectedProduct
    }

    return <ProductContext.Provider value={value}>
        {pending ? <p>Loading data...</p> : children }
    </ProductContext.Provider>
}