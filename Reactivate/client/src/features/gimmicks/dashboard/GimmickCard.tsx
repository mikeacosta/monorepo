import { Box, Button, Card, CardActions, CardContent, Chip, Typography } from "@mui/material";

type Props = {
  gimmick: Gimmick
  selectGimmick: (id: string) => void
  deleteGimmick: (id: string) => void
}

const GimmickCard = ({ gimmick, selectGimmick, deleteGimmick }: Props) => {
  return (
    <Card sx={{ borderRadius: 3 }}>
      <CardContent>
        <Typography variant="h5" component="div">
          {gimmick.title}
        </Typography>
        <Typography sx={{ color: 'text.secondary', mb: 1 }}>
          {gimmick.date}
        </Typography>
        <Typography variant="body2">
          {gimmick.description}
        </Typography>
        <Typography variant="subtitle1">
          {gimmick.city} / {gimmick.venue}
        </Typography>
      </CardContent>
      <CardActions sx={{ display: 'flex', justifyContent: 'space-between', paddingBottom: 2 }}>
        <Chip label={gimmick.category} variant="outlined" />
        <Box display='flex' gap={3}>
          <Button onClick={() => deleteGimmick(gimmick.id)} variant="contained" color="error" size="medium">Delete</Button>
          <Button onClick={() => selectGimmick(gimmick.id)} variant="contained" size="medium">View</Button>
        </Box>
      </CardActions>      
    </Card>
  )
}
export default GimmickCard