// ProductPage.jsx
import { useParams, useLocation } from 'react-router-dom';
import "./App.css"
import SubcategoryPage from './components/pages/subcategoryPage';

function CategoryMenu() {
  const { category } = useParams();
  const location = useLocation();

  // wszystko po kategorii
  const subPath = location.pathname.replace(`/${category}`, '').replace(/^\/+/, '');

  const subSegments = subPath ? subPath.split('/') : [];

  return (
    <div className="category-switcher">
      {subSegments.length === 0 && <h1>Kategoria: {category}</h1>}
      {subSegments.length === 1 && <SubcategoryPage category={category} subcategory={subSegments[0]}/>} 
      {subSegments.length === 2 && <h3>Produkt: {subSegments[1]}</h3>}
    </div>

    // <h2>Podkategoria: {subSegments[0]}</h2>
  );
}
export default CategoryMenu;