// ProductPage.jsx
import { useParams } from 'react-router-dom';

function ProductPage() {
  const { id } = useParams(); // odczytuje :id z URL

  return (
    <div>
      <h1>Produkt o ID: {id}</h1>
    </div>
  );
}
export default ProductPage;