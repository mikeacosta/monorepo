import './Search.css';

const Search = () => {
  return (
    <form className="Search">
      <input name="search" id="search" placeholder="Search recipes" />
      <button type="submit">Search</button>
    </form>
  );
};

export default Search;