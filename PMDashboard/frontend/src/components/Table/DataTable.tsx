import DataTable, { type TableColumn } from "react-data-table-component";
import type { IProduct } from "../../types/IProduct";
import { ProductContext } from "../../services/Context/product-context";
import { useContext } from "react";
import { mapCategoryFromNumber } from "../../types/MapCategory";
import { TableHeaderComponent } from "./TableHeaderComponent";

const columns: TableColumn<IProduct>[] = [
    {
        name: 'Date Added',
        selector: row => row.dateAdded,
        sortable: true,
      },
      {
    name: 'Name',
    selector: row => row.name,
    sortable: true
  }, {
    name: 'Category',
    selector: row => mapCategoryFromNumber(row.category),
    sortable: true
  }, {
    name: 'Price',
    selector: row => row.price,
    sortable: true
  }, {
    name: 'Stock Available',
    selector: row => row.stockQuantity,
    sortable: true
  }
]

export default function DataTableComponent({toggleModal}: {toggleModal: () => void}) {
    const {products, setSelectedProduct } = useContext(ProductContext)

    return (
        <DataTable
            defaultSortFieldId={"Date Added"}
            defaultSortAsc={false}
            pagination
            fixedHeaderScrollHeight="300px"
            columns={columns}
            data={products}
            selectableRows
            selectableRowsHighlight
            subHeader
            subHeaderComponent={<TableHeaderComponent toggleModal={toggleModal} />}
            subHeaderWrap
            selectableRowsSingle={true}
            onSelectedRowsChange={(x: { selectedRows: IProduct[] }) => {
                setSelectedProduct(x.selectedRows[0])
            }}
            responsive
      ></DataTable>
    )
}