import Button from '@mui/material/Button';
import { memo, useContext } from 'react';
import { ProductContext } from '../../services/Context/product-context';

export const TableHeaderComponent = memo(({toggleModal}: {toggleModal: () => void}) => {
    const context = useContext(ProductContext);
    return(
        <>
            <Button variant="outlined" color="success" onClick={() => toggleModal()}
                    >NEW</Button>
            <Button variant="outlined" color="error" disabled={!context.selectedProduct} onClick={() => 
                context.removeItemFromProducts()
                }>DELETE</Button>
        </>
    );
})