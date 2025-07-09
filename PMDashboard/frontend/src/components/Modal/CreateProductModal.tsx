import TextField from "@mui/material/TextField";
import ModalComponent from "./ModalComponent";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Select from "@mui/material/Select";
import MenuItem from "@mui/material/MenuItem";
import { Category } from "../../types/Category";
import { useContext, useRef } from "react";
import { ProductContext } from "../../services/Context/product-context";
import { mapCategoryFromString } from "../../types/MapCategory";

export default function CreateProductModal({open, onClose}: {open: boolean, onClose: () => void}) {
    const {addItemToProducts} = useContext(ProductContext)
    const nameRef = useRef<HTMLInputElement>(null)
    const categoryRef = useRef<HTMLSelectElement>(null)
    const priceRef = useRef<HTMLInputElement>(null)
    const stockQuantityRef = useRef<HTMLInputElement>(null)

    return (
        <ModalComponent open={open} onClose={onClose}>
            <Box
                component="form"
                sx={{
                    display: 'flex',
                    flexDirection: 'column',
                    gap: 2
                }}
                onSubmit={(e)=> {
                    e.preventDefault()
                    addItemToProducts({
                        name: nameRef.current?.value || "",
                        category: mapCategoryFromString(categoryRef.current?.value || "Default") ?? 0,
                        price: parseFloat(priceRef.current?.value || "0"),
                        stockQuantity: Number(stockQuantityRef.current?.value || 0)
                    })
                    onClose()
                }}
            >
                <h3>Create Product</h3>
                <TextField required id="standard-basic" label="Name" variant="outlined" inputRef={nameRef} />
                <Select required id="standard-basic" label="Category" variant="outlined" inputRef={categoryRef} defaultValue={Category.Default}>
                    {Object.values(Category).map((category, index) => (
                        <MenuItem key={index} value={category}>{category}</MenuItem>
                    ))}
                </Select>
                <TextField required id="standard-basic" defaultValue={"0"} label="Price" variant="outlined" inputRef={priceRef} type="number" inputProps={{ min: 0, step: 'any' }}
                    onBeforeInput={(e) => {
                        const event = e as unknown as InputEvent & { target: HTMLInputElement; data: string };
                        const input = event.target;
                        const nextValue = input.value + (event.data || "");
                        if (!/^\d*\.?\d*$/.test(nextValue)) {
                            e.preventDefault();
                        }
                    }}
                />
                <TextField required id="standard-basic" defaultValue={"0"} label="Stock Quantity" variant="outlined" inputRef={stockQuantityRef} type="number" inputProps={{ min: 0 }}
                    onBeforeInput={(e) => {
                        const event = e as unknown as InputEvent & { target: HTMLInputElement; data: string };
                        const input = event.target;
                        const nextValue = input.value + (event.data || "");
                        if (!/^\d*$/.test(nextValue)) {
                            e.preventDefault();
                        }
                    }}
                />
                <Button type="submit" variant="contained" color="primary">Create</Button>
            </Box>
        </ModalComponent>
    )
}