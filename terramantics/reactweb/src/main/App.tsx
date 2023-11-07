import './App.css';
import Header from './Header';
import HouseList from '../house/HouseList';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import HouseDetail from '../house/HouseDetail';

function App() {
  return (
    <BrowserRouter>
      <div className="Container">
        <Header subtitle="Providing houses all over the world" />
        <Routes>
          <Route path="/" element={<HouseList />}></Route>
          <Route path="/houses/:id" element={<HouseDetail />}></Route>
        </Routes>
      </div>    
    </BrowserRouter>
  );
}

export default App;
