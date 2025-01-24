import './Homepage.css';
import Search from '../../components/search/Search';

const Homepage = () => {

  const getDataFromSearchComponent = (data) => {
    console.log(data);

    const url = `https://api.spoonacular.com/recipes/complexSearch?apiKey=3083f903870640d8a4dec76ea6679b41&query=${data}`;

    async function getRecipes() {
      const response = await fetch(url);
      const result = await response.json();

      console.log(result)
    }

    getRecipes();
  };

  return (
    <div className="homepage">
      <Search sendDataToHomeComponent={getDataFromSearchComponent} />
    </div>
  );
};

export default Homepage;