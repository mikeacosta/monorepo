
import { Grid } from "@mui/material"
import GimmicksList from "./GimmicksList"

type Props = {  
  gimmicks: Gimmick[]
  selectGimmick: (id: string) => void 
  deleteGimmick: (id: string) => void
}

const GimmicksDashboard = ({ gimmicks, selectGimmick, deleteGimmick }: Props) => {
  return (
    <Grid container spacing={3}>
      <Grid size={7}>
        <GimmicksList 
          gimmicks={gimmicks} 
          selectGimmick={selectGimmick}
          deleteGimmick={deleteGimmick}
        />
      </Grid>
    </Grid>
  )
}

export default GimmicksDashboard