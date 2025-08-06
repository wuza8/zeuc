import { useEffect, useState } from 'react';
import './subcategoryPage.css';
import ProductCard from '../content/productCard';
import ProductGroup from '../content/productGroup';

function SubcategoryPage({ category, subcategory }) {
    const [ data, setData ] = useState(null);

    useEffect(() => {
        // Możesz tutaj dodać logikę do pobierania danych dla subkategorii
        fetch(`/api/sites/${category}/${subcategory}`)
            .then(response => response.json())
            .then(data => {
                setData(data);
            }).catch(error => {
                console.error('Błąd podczas pobierania danych:', error);
            });
    }, [category, subcategory]);

  return <div className="product-group">
    {data != null && <span>
        <h1 className="cyan-color subcategory-header">{data.header}</h1>
        <p>{data.description}</p>
        {data.productContainers.map((container, index) => (
            <ProductGroup wrapname={container.name}>
                {container.items.map((product, idx) => (
                    <ProductCard key={idx} product={product} />
                ))}
            </ProductGroup>
        ))}
    </span>}
</div>;
}

export default SubcategoryPage;