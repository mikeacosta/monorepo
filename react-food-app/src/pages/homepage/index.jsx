import Search from '../../components/search'
import './style.css'

const testData = 'blah blah';

const Homepage = ()=>{

  const getSearchInput = (inputData) => {
    console.log('input is: ', inputData);

    // call API
  }  

  return (
    <div className="homepage">
      <Search processSearchInput={getSearchInput} dummydata = {testData}/>
    </div>
  )
}

export default Homepage;