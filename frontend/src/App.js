
import './App.css';
import SearchAndCategories from './components/header/searchAndCategories';
import Basket from './components/header/basket';
import ProductGroup from './components/content/productGroup';
import ProductCard from './components/content/productCard';
import CategoryTooltip from './components/header/categoryTooltip';
import Layout from './layout';
import HomePage from './homePage';
import ProductPage from './productPage';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import CategoryMenu from './categoryMenu';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<HomePage />} />
          <Route path="/:category/*" element={<CategoryMenu />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );

  
}

export default App;
