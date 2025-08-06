import CategoryTooltip from './categoryTooltip';
import './searchAndCategories.css';
import { useState, useEffect, useRef } from 'react';
import loading from '../../img/loading.svg';

function SearchAndCategories() {
  const [isCategoryOpen, setIsCategoryOpen] = useState(false);
  const [isSearchOpen, setIsSearchOpen] = useState(false);
  const [categories, setCategories] = useState(null);
  const [currentCategory, setCurrentCategory] = useState(null);
  
  const categoryClickableRef = useRef(null);
  const searchClickableRef = useRef(null);
  const [searchValue, setSearchValue] = useState("")

  const searchResults = useState([]);

  function toggleTooltip() {
    setIsCategoryOpen(!isCategoryOpen);
  }
  
  useEffect(() => {
    fetch('/api/category')
      .then(response => response.json())
      .then(data => setCategories(data))
      .catch(error => console.error('Błąd podczas pobierania kategorii:', error));

    function handleClickOutside(event) {
      if (
        searchClickableRef.current &&
        !searchClickableRef.current.contains(event.target)
      ) {
        setIsSearchOpen(false);
      }
      if (
        categoryClickableRef.current &&
        !categoryClickableRef.current.contains(event.target)
      ) {
        setIsCategoryOpen(false);
      }
    }

    document.addEventListener("mousedown", handleClickOutside);
    return () => {
      document.removeEventListener("mousedown", handleClickOutside);
    };
  }, []);

  function searchChange(event){
    setSearchValue(event.target.value);
    setIsSearchOpen(true);
    console.log(searchValue);
  }

  function sendSearchQuery(){

  }

  return <div className="search-and-categories" >
    <span ref={searchClickableRef}>
      <input value={searchValue} className="search-bar" placeholder="Wyszukaj produkt..." onChange={searchChange}/>
      {isSearchOpen && <div id="search-dropdown">
        {searchResults.length == 0 && <img id="loading-symbol" src={loading}/>}
        {searchResults.length != 0 && searchResults.map(product => {
          <div id="searchResultTile">
          </div>
        })}
      </div>}
    </span>

    <span ref={categoryClickableRef}>
      { categories != null && <div className="categories">
        {categories.map((category) => (
            <div key={category.link} className="category" onClick={() => toggleTooltip()} onMouseEnter={()=>setCurrentCategory(category)}>{category.name}</div>
        ))}
      </div> }
      
      {isCategoryOpen && (<CategoryTooltip category={currentCategory} closeTooltip={toggleTooltip}/>)}
    </span>
</div>;
}

export default SearchAndCategories;