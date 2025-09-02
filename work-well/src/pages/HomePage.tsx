import Hero from '../components/Hero';
import HomeCards from '../components/HomeCards';
import JobListings from '../components/JobListings';
import HomeFooter from '../components/HomeFooter';

const HomePage = () => {
  return (
    <>
      <Hero title="Become a React Dev" 
        subtitle="Find the React job that fits your skills and needs" />
      <HomeCards />
      <JobListings />
      <HomeFooter />
    </>
  );
};
export default HomePage;