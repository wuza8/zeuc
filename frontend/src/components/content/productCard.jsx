import cartIcon from './cart.png';
import './productCard.css';


function ProductCard({product}) {
    if(product!=null && product.imageUrl != null && !product.imageUrl.startsWith("/")){
        product.imageUrl = "/" + product.imageUrl;
    }
  return <div className="product-card">
    <div className="product-image">
      <img src={product.imageUrl} alt="Product Image" />
      </div>
    <div className="product-name">
        <span>{product.name}</span>
    </div>
    <div className="product-bottom-wrapper">
        <div className="product-price">
            <span>{product.price}zł</span>
        </div>
        <div className="product-button">
            <div className='tobasket-button'><img src={cartIcon}/></div>
        </div>
    </div>
</div>;
}

export default ProductCard;