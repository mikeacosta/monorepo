import { useState } from 'react';
import './Search.css';

const Search = (props) => {

  const [inputValue, setInputValue] = useState('');

  const { sendDataToHomeComponent } = props;

  const handleInputValue = (event) => {
    const {value} = event.target;
    setInputValue(value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    sendDataToHomeComponent(inputValue);
  };

  return (
    <form onSubmit={handleSubmit} className="Search">
      <input name="search" id="search"
        onChange={handleInputValue} value={inputValue} placeholder="Search recipes" />
      <button type="submit">Search</button>
    </form>
  );
};

export default Search;