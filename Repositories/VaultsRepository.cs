using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{
    public class VaultsRepository
    {
        private IDbConnection _db;
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }

        // GET ALL VAULTS
        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM vaults");
        }

        // GET VAULTS BY ID
        public Vault GetById(int id)
        {
            return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new { id }).FirstOrDefault();
        }

        // CREATE VAULT
        public Vault Create(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaults (name,description)
            VALUES (@Name, @Description);
            SELECT LATS_INSERT_ID();", vault
            );
            vault.Id = id;
            return vault;
        }

        // UPDATE VAULT
        public Vault Update(Vault vault)
        {
            _db.Execute(@"UPDATE vaults
            SET name = @Name, description = @Description
            WHERE id= @Id;", vault);
            return vault;
        }

        // DELETE VAULT
        public Vault Delete(Vault vault)
        {
            _db.Execute("DELETE FROM vaults WHERE id = @Id", vault);
            return vault;
        }

        // GET VAULT BY USER ID
        public IEnumerable<Vault> GetVaultByUserId(string id)
        {
            return _db.Query<Vault>(@"
            SELECT * FROM uservaults
            INNER JOIN vaults ON vault.id = uservaults.vaultId
            WHERE userId = @id", new { id });
        }

        public int Delete(int id)
        {
            return _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
        }
    }
}