import {
  Route,
  createBrowserRouter,
  createRoutesFromElements,
  RouterProvider,
} from 'react-router-dom';
import HomePage from './pages/HomePage';
import MainLayout from './layouts/MainLayout';

const App = () => {
  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route path='/' element={<MainLayout />}>
        <Route index element={<HomePage />} />
      </Route>
    )
  );

  return <RouterProvider router={router} />;

  // return (
  //   <>
  //     <Navbar />
  //     <Hero title="Become a React Dev" 
  //       subtitle="Find the React job that fits your skills and needs" />
  //     <HomeCards />
  //     <JobListings />
  //     <HomeFooter />
  //   </>
  // )
}

export default App