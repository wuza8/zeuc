import basket from '../../img/basket.png';
import './basket.css';

function Basket() {
  return <div className="basket">
    <img src={basket} className="basket-icon"/>
    <div class="basket-number">1</div>
</div>;
}

export default Basket;