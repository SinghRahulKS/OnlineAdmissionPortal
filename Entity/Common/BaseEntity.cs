using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{
    public class BaseEntity
    {
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the LastUpdated Date time
        /// </summary>
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets the Created by
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the LastUpdated By
        /// </summary>
        public string LastUpdatedBy { get; set; }

        private int _currentPage;
        public int CurrentPage
        {
            get
            {
                if (_currentPage == 0)
                {
                    return 1;
                }
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }

    }
}
