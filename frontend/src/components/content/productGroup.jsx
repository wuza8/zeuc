import './productGroup.css';

function ProductGroup({ wrapname, children }) {
  return <div className="product-group">
    <div className="group-header">
        <span>{wrapname}</span>
        <span class="line"></span>
    </div>
    <div className="group-children">
      {children}
    </div>
</div>;
}

export default ProductGroup;