import { expect, test, describe, vi, afterEach } from 'vitest'
import { render, act, cleanup } from '@testing-library/react'
import type { IProduct } from '../../types/IProduct'
import { Category } from '../../types/Category'
import { useContext } from 'react'
import ProductProvider from './product-provider'
import { ProductContext } from './product-context'
import { mapCategoryFromString } from '../../types/MapCategory'

const TestData = () => {
    const {products, addItemToProducts, removeItemFromProducts} = useContext(ProductContext)
    return (
        <>
        <ul >
            {products.map((product) => (
                <li key={product.id}>
                    <div>Name: {product.name}</div>
                    <div>Category: {product.category}</div>
                    <div>Price: {product.price}</div>
                    <div>Stock: {product.stockQuantity}</div>
                    <div>Date Added: {product.dateAdded}</div>
                </li>
            ))}
        </ul>
        </>
    )
}

const mockResponse: IProduct[] = [{
    id: 1,
    category: mapCategoryFromString(Category.Clothing),
    dateAdded: new Date().toISOString(),
    name: "test",
    price: 10.00,
    stockQuantity: 10
    }
]

describe("test", () => {
    afterEach(() => {
        cleanup();
      });
      
    test('get all api', async() => {
        
        global.fetch = await vi.fn().mockResolvedValue({
            json: () => Promise.resolve(mockResponse)
        });
        const page = await act(async () => render(<ProductProvider children={<TestData/>}/>))
        expect(fetch).toHaveBeenCalledTimes(1);
        expect(await page.findByText("Name: " + mockResponse[0].name))
        expect(await page.findByText("Category: " + mockResponse[0].category))
    })
    }
)