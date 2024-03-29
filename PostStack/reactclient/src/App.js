import { render } from "@testing-library/react";
import React, { useState } from "react";
import Constants from "./utils/Constants";

function App() {
  const [posts, setPosts] = useState([]);

  function getPosts() {
    const url = Constants.API_URL_GET_ALL_POSTS;

    fetch(url, {
      method: 'GET'
    })
    .then(response => response.json())
    .then(postsFromServer => {
      console.log(postsFromServer);
      setPosts(postsFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    })
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>ASP.NET Core + React</h1>
            <div className="mt-5">
              <button onClick={getPosts} className="btn btn-dark btn-lg w-100">Get Posts from server</button>
              <button onClick={() => {}} className="btn btn-secondary btn-lg w-100 mt-4">Create new Post</button>
            </div>
          </div>
          {renderPostsTable()}
        </div>
      </div>
    </div>
  );

  function renderPostsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">PostId</th>
              <th scope="col">Title</th>
              <th scope="col">Content</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {posts.map((post) => (
              <tr key={post.postId}>
                <th scope="row">{post.postId}</th>
                <td>{post.title}</td>
                <td>{post.content}</td>
                <td>
                  <button className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
  
        <button onClick={() => setPosts([])} className="btn btn-dark btn-lg w-100">Empty React posts array</button>
      </div>
    );
  }  
}

export default App;
