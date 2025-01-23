import './Homepage.css';
import Search from '../../components/search/Search';

const Homepage = () => {

  const getDataFromSearchComponent = (data) => {
    console.log(data);
  };

  return (
    <div className="homepage">
      <Search sendDataToHomeComponent={getDataFromSearchComponent} />
    </div>
  );
};

export default Homepage;