namespace MiniGigWebApi.Domain
{
    public static class GigMapper
    {
        // Map domain entity to DTO/model
        public static GigModel ToModel(Gig gig)
        {
            if (gig == null) return null;

            var model = new GigModel
            {
                // Map only explicitly required fields to avoid reflection/AutoMapper.
                // Add other property mappings here as needed.
                Category = gig.MusicGenre != null ? gig.MusicGenre.Category : null,
                // If GigModel.MusicGenreId is non-nullable int, map to 0 when missing.
                MusicGenreId = gig.MusicGenre != null ? gig.MusicGenre.Id : 0,
                Name = gig.Name,
                GigDate = gig.GigDate
            };

            return model;
        }

        // Map DTO/model back to domain entity
        public static Gig ToEntity(GigModel model)
        {
            if (model == null) return null;

            var gig = new Gig
            {
                // Map other simple properties here if needed.
                Name = model.Name,
                GigDate = model.GigDate
            };

            // Prefer explicit id mapping when available, otherwise try to set by category.
            if (model.MusicGenreId != 0)
            {
                gig.MusicGenre = new MusicGenre { Id = model.MusicGenreId };
            }
            else if (!string.IsNullOrEmpty(model.Category))
            {
                gig.MusicGenre = new MusicGenre { Category = model.Category };
            }

            return gig;
        }

        // Optional: update an existing entity from a model without replacing the instance
        public static void UpdateEntity(GigModel model, Gig gig)
        {
            if (model == null || gig == null) return;

            // Update MusicGenre info explicitly
            if (model.MusicGenreId != 0)
            {
                if (gig.MusicGenre == null) gig.MusicGenre = new MusicGenre();
                gig.MusicGenre.Id = model.MusicGenreId;
            }
            else if (!string.IsNullOrEmpty(model.Category))
            {
                if (gig.MusicGenre == null) gig.MusicGenre = new MusicGenre();
                gig.MusicGenre.Category = model.Category;
            }

            // Update other properties explicitly as required.
        }
    }
}