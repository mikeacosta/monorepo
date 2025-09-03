import axios from "axios"
import { useEffect, useState } from "react"
import JobListing from "./JobListing"
import Spinner from "./Spinner"

const JobListings = ({ isHome = false }) => {
  const [jobs, setJobs] = useState<Job[]>([])
  const[loading, setLoading] = useState(true);

  useEffect(() => {
    axios.get<Job[]>("https://localhost:5001/api/jobs")
      .then(response => {
        setJobs(response.data);
        setLoading(false);
      })
  }, [])  

  const showJobs = isHome ? jobs.slice(0, 3) : jobs;

  return (
    <section className="bg-blue-50 px-4 py-10">
      <div className="container-xl lg:container m-auto">
        <h2 className="text-3xl font-bold text-indigo-500 mb-6 text-center">
          Browse Jobs
        </h2>
        {loading && <Spinner loading={loading} />}
        <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
          {showJobs.map(job => (
            <JobListing key={job.id} job={job} />
          ))}
        </div>
      </div>
    </section>    
  )
}

export default JobListings