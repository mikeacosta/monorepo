import { useState, useEffect } from 'react'
import './App.css'
import api from './api/axiosConfig';
import Layout from './components/Layout';
import Home from './components/home/Home';
import { Routes, Route} from 'react-router-dom';

function App() {
  const [movies, setMovies] = useState();

  const getMovies = async () => {

    try {
      const response = await api.get("/api/v1/movies");

      console.log(response.data);

      setMovies(response.data);
    } catch(err) {
      console.log(err);
    }
  }

  useEffect(() => {
    getMovies();
  }, [])

  return (
    <div className="App">
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route path="/" element={<Home movies={movies} />}></Route>
        </Route>
      </Routes>
    </div>
  )
}

export default App;
