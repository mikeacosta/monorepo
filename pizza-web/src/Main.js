import React, { useState, useEffect } from "react";
import Pizza from "./components/Pizza.js"

const Main = () => {
    const [pizzas, setPizzas] = useState([]);
    useEffect(() => {
        fetchData();
    }, [])

    function fetchData() {
        fetch("/api/pizza")
            .then(response => response.json())
            .then(data => setPizzas(data))
    }

    const data = pizzas.map(pizza => <Pizza pizza={pizza} />)

    return (<React.Fragment>
        {pizzas.length === 0 ?
            <div>No pizzas</div> :
            <div>{data}</div>
        }
    </React.Fragment>)
}

export default Main;