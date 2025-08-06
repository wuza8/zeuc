import "./App.css"
import ProductGroup from './components/content/productGroup';
import ProductCard from './components/content/productCard';
import { useEffect, useState } from "react";

function HomePage() {

    const [ data, setData ] = useState(null);
    
    useEffect(() => {
        // Możesz tutaj dodać logikę do pobierania danych dla subkategorii
        fetch(`/api/sites/bestsellers`)
            .then(response => response.json())
            .then(data => {
                setData(data);
            }).catch(error => {
                console.error('Błąd podczas pobierania danych:', error);
            });
    });


    return (
        <span>
            <div style={{float:"left"}}>
                <h2>Witamy w sklepie ZEUC!</h2>

                <p>
                    W naszym sklepie znajdziesz tylko najlepsze produkty z dziedziny elektroniki cyfrowej,
                    skierowanej do szerokiego grona odbiorców! No dalej, rozejrzyj się i kup coś u nas! 
                    Mamy świetne ceny i świetne produkty, samo złoto.
                </p>
            </div>
            {data != null && <span>
                <ProductGroup wrapname="Bestsellery">
                {data.map((product,idx) => (
                    <ProductCard key={idx} product={product} />
                ))}
                </ProductGroup>
            </span>}
        </span>
    );
}

export default HomePage;