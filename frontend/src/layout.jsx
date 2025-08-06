import { Outlet } from 'react-router-dom';
import "./App.css"
import logo from './img/logo.png';
import Basket from './components/header/basket';
import SearchAndCategories from './components/header/searchAndCategories';
import {useNavigate} from 'react-router-dom';

function Layout() {
    const navigate = useNavigate();
  return (
    <div>
      <header>
        <div className="logo-box" onClick={() => navigate('/')}>
          <img src={logo} className="logo" alt="zeuc logo" />
        </div>
        <Basket/>
        <SearchAndCategories />
      </header>
      <div className="content">
        <Outlet />
      </div>
    </div>
  );
}

export default Layout;