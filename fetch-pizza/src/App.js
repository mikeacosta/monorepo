import React, { useEffect, useState } from "react"
import logo from './logo.svg';
import './App.css';

function App() {
  const [pizzas, setPizzas] = useState([])

  const fetchPizzas = () => {
    fetch("https://localhost:7025/api/pizza")
      .then(response => {
        return response.json()
      })
      .then(data => {
        setPizzas(data)
      })    
  }

  useEffect(() => {
    fetchPizzas()
  }, [])

  return (
    <div>
      {pizzas.length > 0 && (
        <ul>
          {pizzas.map(pizza => (
            <li key={pizza.id}>{pizza.name}</li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;
