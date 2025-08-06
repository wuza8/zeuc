import './categoryTooltip.css';
import { useNavigate } from 'react-router-dom';

function CategoryTooltip({category, closeTooltip}) {
    const navigate = useNavigate();

    return <div className="category-tooltip">
    {category.subcategories.map((subcategory) => (
        <div key={subcategory.link} className="category-link" onClick={() => {navigate('/'+category.link+'/'+subcategory.link);closeTooltip();}}>{subcategory.name}</div>
    ))}
    </div>;
}

export default CategoryTooltip;