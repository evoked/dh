import { useState } from 'react'
import './App.css'
import ProductProvider from './services/Context/product-provider';
import DataTableComponent from './components/Table/DataTable';
import CreateProductModal from './components/Modal/CreateProductModal';
import PieChart from './components/Graph/PieChart';

function App() {
  const [showModal, setShowModal] = useState(false)
  
  return (
    <ProductProvider>
      <DataTableComponent
        toggleModal={() => setShowModal(!showModal)}
      />
      <PieChart key={"pie-chart"}></PieChart>
      <CreateProductModal
        open={showModal}
        onClose={() => setShowModal(false)}
      />
    </ProductProvider>
  )
}

export default App
