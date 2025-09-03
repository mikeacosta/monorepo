type Job = {
  id: number
  title: string
  type: string
  description: string
  location: string
  salary: string
  company: Company
};

type Company = {
  name: string
  description: string
  contactEmail: string
  contactPhone: string  
}
