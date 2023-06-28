import './style.css'
import { useState } from 'react';


const Search = (props) => {
  console.log('props')
  console.log(props)
  const {processSearchInput} = props;

  const [inputValue, setInputValue] = useState()  // initial value

  const handleInputValue = (event)=>{
    const{value} = event.target;
    // set the updated state
    setInputValue(value);
  }

  // console.log(inputValue);

  const handleSubmit = (event) => {
    event.preventDefault();
    processSearchInput(inputValue)
  }

  return (
    <form onSubmit={handleSubmit} className="Search">
      <input name="search" onChange={handleInputValue} placeholder="Search Recipes" id="search"/>
      <button type="submit">Search</button>
    </form>
  )
}

export default Search;